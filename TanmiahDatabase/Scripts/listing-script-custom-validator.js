$(document).ready(function () {
    $('#listingform').validate({
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
            'ListingImg': {
                required: true,
                minlength: 20
            },

            'ListingProd': {
                required: true,
                minlength: 5
            },

            'ListingProdTitle': {
                required: true,
                minlength: 10
            },

            'ListingDetail': {
                required: true,
                minlength: 20
            },
        },
        messages: {
            'ListingImg': {
                required: 'Please provide a Listing Image',
                minlength: 'Listing Image must be at least 5 characters long'
            },

            'ListingProd': {
                required: 'Please provide a Listing Product',
                minlength: 'Listing Product must be at least 5 characters long'
            },

            'ListingProdTitle': {
                required: 'Please provide a Listing product Title',
                minlength: 'Listing product Title must be at least 10 characters long'
            },

            'ListingDetail': {
                required: 'Please provide a Listing Detail',
                minlength: 'Listing Detail must be at least 20 characters long'
            },

        }
    });
});   