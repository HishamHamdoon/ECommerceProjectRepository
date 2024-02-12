﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#companytblData').DataTable({
        "ajax": { url: '/admin/company/GetAll'},
        "columns": [
            {data:'name',"width":"15%"},
            { data:'streetAddress',"width":"15%"},
            {data:'city',"width":"15%"},
            {data:'state',"width":"15%"},
            {data:'postalCode',"width":"15%"},
            {data:'phoneNumber',"width":"15%"},
             {
                data: 'id',
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2">
                <i class="bi bi-pencil"></i>
            </a>
            <a onClick=Delete('/admin/company/delete?id=${data}') class="btn btn-danger mx-2">
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
            Swal.fire('company deleted successfully')
        } else if (result.isDenied) {
            Swal.fire('company don\'t deleted', '', 'info')
        }
    })
}