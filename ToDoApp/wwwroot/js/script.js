$(document).ready(function () {
    function loadTodos() {
        $.ajax({
            url: 'https://localhost:7165/api/todo/GetAll',
            method: 'GET',
            success: function (data) {
                $('#todoItems').empty();
                data.forEach(function (todo) {
                    $('#todoItems').append(`
                        <li data-id="${todo.id}" class="list-group-item ${todo.isCompleted ? 'completed' : ''}">
                            <div class="todo-item">
                                <input type="checkbox" class="completeTodo" ${todo.isCompleted ? 'checked' : ''}>
                                <span class="todo-content">${todo.title} - ${todo.description}</span>
                                <button class="btn btn-danger btn-sm deleteTodo">
                                    <i class="material-icons">delete</i>
                                </button>
                            </div>
                        </li>
                    `);
                });
            },
            error: function () {
                showToast('Görevler yüklenirken bir hata oluştu.', 'danger');
            }
        });
    }

    function showToast(message, type) {
        const toastElement = $('#myCustomToast');
        toastElement.find('.toast-body').text(message);
        toastElement.removeClass('bg-success bg-danger bg-warning').addClass(`bg-${type}`);
        toastElement.toast({ delay: 3000 });
        toastElement.toast('show');
    }

    $('#addTodo').click(function () {
        const title = $('#title').val().trim();
        const description = $('#description').val().trim();

        if (!title || !description) {
            showToast('Görev başlığı ve açıklaması boş olamaz!', 'danger');
            return;
        }

        $.ajax({
            url: 'https://localhost:7165/api/todo/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                title: title,
                description: description,
                isCompleted: false
            }),
            success: function () {
                loadTodos();
                $('#title').val('');
                $('#description').val('');
                showToast('Görev başarıyla eklendi!', 'success');
            },
            error: function (xhr, status, error) {
                console.error('Hata:', xhr.responseText);
                showToast('Görev eklenirken bir hata oluştu.', 'danger');
            }
        });
    });

    $(document).on('click', '.deleteTodo', function () {
        const id = $(this).closest('li').data('id');

        $.ajax({
            url: `https://localhost:7165/api/todo/Delete/${id}`,
            method: 'DELETE',
            success: function () {
                loadTodos();
                showToast('Görev başarıyla silindi!', 'success');
            },
            error: function () {
                showToast('Görev silinirken bir hata oluştu.', 'danger');
            }
        });
    });

    $(document).on('change', '.completeTodo', function () {
        const li = $(this).closest('li');
        const id = li.data('id');
        const isCompleted = $(this).is(':checked');
        const title = li.find('.todo-content').text().split(' - ')[0].trim();
        const description = li.find('.todo-content').text().split(' - ')[1].trim();

        $.ajax({
            url: `https://localhost:7165/api/todo/Update/${id}`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({
                id: id,
                title: title,
                description: description,
                isCompleted: isCompleted
            }),
            success: function () {
                loadTodos();
                showToast('Görev başarıyla güncellendi!', 'success');
            },
            error: function () {
                showToast('Görev güncellenirken bir hata oluştu.', 'danger');
            }
        });
    });

    loadTodos();
});
