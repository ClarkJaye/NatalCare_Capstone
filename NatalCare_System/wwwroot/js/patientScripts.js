$(document).ready(function () {
    // Initialize DataTables
    $('#patientsTable').DataTable({
        paging: true,
        lengthChange: true,
        searching: true,
        ordering: true,
        lengthMenu: [10, 20, 50, 100],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search patients..."
        },
        language: {
            paginate: {
                previous: "Previous",
                next: "Next"
            }
        },
        info: true,
        autoWidth: false,
        responsive: true,
        columnDefs: [
            { orderable: false, targets: -1 }
        ]
    });

    $('#patientsTable').on("click", ".dlt-Btn", function (e) {
        var patientid = $(this).data('patientid');
        DeletePatient(patientid);
    });
});





//Load All Records
function LoadAllPatientsComponent() {
    $.ajax({
        url: '@Url.Action("GetAllPatients", "Patient")',
        async: true,
        success: function (result) {
            $('#patientsContainer').html(result);
        },
        error: function () {
            toastr.error("Failed to reload the Family Planning records.");
        }
    });
}


// Delete Patient
function DeletePatient(patientid) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this, but you can see this on deleted history!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: '@Url.Action("Delete", "Patient")',
                data: { patientid: patientid },
                success: function (result) {
                    if (result.isSuccess) {
                        toastr.success(result.message);
                        LoadAllPatientsComponent();
                    } else {
                        toastr.error(result.message);
                    }
                },
                error: function () {
                    console.log('Unable to delete the patient.');
                }
            });
        }
    });
}