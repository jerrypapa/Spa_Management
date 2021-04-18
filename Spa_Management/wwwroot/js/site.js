// Write your JavaScript code.
$(document).ready(function () {

    (function ($) {

        var $form = $('#filter-form');
        var $helpBlock = $("#filter-help-block");

        //Watch for user typing to refresh the filter
        $('#filter').keyup(function () {
            var filter = $(this).val();
            $form.removeClass("has-success has-error");

            if (filter == "") {
                $helpBlock.text("No filter applied.")
                $('.searchable .panel').show();
            } else {
                //Close any open panels
                $('.collapse.in').removeClass('in');

                //Hide questions, will show result later
                $('.searchable .panel').hide();

                var regex = new RegExp(filter, 'i');

                var filterResult = $('.searchable .panel').filter(function () {
                    return regex.test($(this).text());
                })

                if (filterResult) {
                    if (filterResult.length != 0) {
                        $form.addClass("has-success");
                        $helpBlock.text(filterResult.length + " question(s) found.");
                        filterResult.show();
                    } else {
                        $form.addClass("has-error").removeClass("has-success");
                        $helpBlock.text("No questions found.");
                    }

                } else {
                    $form.addClass("has-error").removeClass("has-success");
                    $helpBlock.text("No questions found.");
                }
            }
        })

    }($));
});

//
//  This function disables the enter button
//  because we're using a form element to filter, if a user
//  pressed enter, it would 'submit' a form and reload the page
//  Probably not needed here on Codepen, but necessary elsewhere
// 
$('.noEnterSubmit').keypress(function (e) {
    if (e.which == 13) e.preventDefault();
});
<script>
    $(function () {
        $("#example1").DataTable();
        //$('#example2').DataTable({
        //  "paging": true,
        //  "lengthChange": false,
        //  "searching": false,
        //  "ordering": true,
        //  "info": true,
        //  "autoWidth": false
        //});
    });</script>

