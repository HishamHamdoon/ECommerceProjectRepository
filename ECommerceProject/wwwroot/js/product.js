var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {url: '/admin/product/GetAll'},
        "columns": [
            {data:'title',"width":"15%"},
            { data:'description',"width":"15%"},
            {data:'isbn',"width":"15%"},
            {data:'author',"width":"15%"},
            {data:'price',"width":"15%"},
            {data:'category.name',"width":"15%"},
            {data:'price',"width":"15%"},
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
                <i class="bi bi-pencil"></i>
            </a>
            <a onClick=Delete('/admin/product/delete?id=${data}') class="btn btn-danger mx-2">
                <i class="bi bi-trash-fill"></i>
            </a>
                    </div>
                    `
                },
                "width": "15%"
            }            
        ]

    });
    
}

function Delete(url) {
    Swal.fire({
        title: 'Do you want to Delete this ?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Yes',
        denyButtonText: `No`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.ajax({
                'url': url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                },

            })
            Swal.fire('product deleted successfully')
        } else if (result.isDenied) {
            Swal.fire('product don\'t deleted', '', 'info')
        }
    })
}