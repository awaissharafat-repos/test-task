$(document).ready(function () {
  $('#sidebarCollapse').on('click', function () {
    $('#sidebar').toggleClass('active');
  });
  $('[data-toggle="tooltip"]').tooltip();
});


var ps = new PerfectScrollbar('#sidebar');
