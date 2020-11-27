$(document).ready(function () {
    $('#breadcrumbform').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'ProductTitle': {
                required: true,
                minlength: 10
            },

        },
        messages: {
            'ProductTitle': {
                required: 'Please provide a product titlr',
                minlength: 'Product Type must be at least 10 characters long'
            },
        }
    });
});   