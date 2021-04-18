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

(function ($) {
  "use strict"; // Start of use strict

  // Smooth scrolling using jQuery easing
  $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      if (target.length) {
        $('html, body').animate({
          scrollTop: (target.offset().top - 54)
        }, 1000, "easeInOutExpo");
        return false;
      }
    }
  });

  // Closes responsive menu when a scroll trigger link is clicked
  $('.js-scroll-trigger').click(function() {
    $('.navbar-collapse').collapse('hide');
  });

  // Activate scrollspy to add active class to navbar items on scroll
  $('body').scrollspy({
    target: '#mainNav',
    offset: 56
  });

  // Collapse Navbar
  var navbarCollapse = function() {
    if ($("#mainNav").offset().top > 100) {
      $("#mainNav").addClass("navbar-shrink");
    } else {
      $("#mainNav").removeClass("navbar-shrink");
    }
  };
  // Collapse now if page is not at top
  navbarCollapse();
  // Collapse the navbar when page is scrolled
  $(window).scroll(navbarCollapse);

  // Hide navbar when modals trigger
  $('.portfolio-modal').on('show.bs.modal', function(e) {
    $('.navbar').addClass('d-none');
  })
  $('.portfolio-modal').on('hidden.bs.modal', function(e) {
    $('.navbar').removeClass('d-none');
  })

})(jQuery); // End of use strict

