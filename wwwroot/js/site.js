
// Pagination handler
$(document).on('click', '.page-link, #filterButton,#search', function (e) {
    e.preventDefault();
    const page = $(this).data('page') || 1; // Default to page 1 if not provided
    callAjax(page);
});

// Clear Filter handler
$(document).on('click', '#clear', function (e) {
    e.preventDefault();
    $('#name').val('');
    $('#dos').val('');
    $('#dob').val('');
    $('#phone').val('');
    $('#token').val('');
    $('#size').val('');
    callAjax(1);
});

// Page size handler
$(document).ready(function () {
    $('#size').change(function () {
        console.log("Size changed to: " + $(this).val());
        callAjax(1);
    });
});

// Show custom toastr notification , first parameter is the message and second being the class , color of the text

function showNotification(message, bgclass) {
    var notification = document.getElementById('notification');
    notification.innerText = message;
    notification.classList.remove('bg-success', 'bg-danger');
    notification.classList.add(bgclass);
    notification.classList.add('show');

    // Hide the notification after 7 seconds
    setTimeout(function () {
        notification.classList.remove('show');
    }, 7000); 
}

// The common Ajax function to handle all the filters ,clear filters and  size change
function callAjax(page) {

    const name = $('#name').val();
    const dos = $('#dos').val();
    const dob = $('#dob').val();
    const phone = $('#phone').val();
    const token = $('#token').val();
    const size = $('#size').val();
    const url = $('#url').val();
    $('#ajaxLoader').show();
    $.ajax({
        url: url,
        type: 'POST',
        data: {
            name,
            dos,
            phone,
            dateTime: dob,
            token,
            pageNumber: page,
            pageSize: size,

        },
        success: function (response) {
            $('#partial-view-table').html(response);
        },
        error: function (xhr) {
            console.error("Error loading page: ", xhr);
        },
        complete: function () {
            // Hide the loader
            $('#ajaxLoader').hide();
        }
    });
}