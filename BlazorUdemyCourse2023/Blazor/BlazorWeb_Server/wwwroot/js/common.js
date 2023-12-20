window.ShowToastr = (type, message) => {

    if (type === "success") {
        toastr.success(message, "Success!", {timeOut: 7000})
    }

    if (type === "error") {
        toastr.error(message, "Error!", { timeOut: 7000 })
    }
}

window.ShowSweetAlert = (type, message) => {

    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        )
    }

    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#delete-confirmation-modal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#delete-confirmation-modal').modal('hide');
}