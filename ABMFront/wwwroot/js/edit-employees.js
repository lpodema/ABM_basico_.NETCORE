$(document).ready(function () {
  //Multiselect - Select2 plug-in
  $("#multi").select2();

  $("#HiringDate").datepicker({ format: "yyyy-mm-dd", language: "en" });
  $("#HiringDate").val($("#HiringDate").datepicker("getFormattedDate"));

  $(function () {
    $("#save").on("click", function (evt) {
      evt.preventDefault();
      $.post("Employee/EditEmployee", $("form").serialize(), function () {
        window.location.href = '@Url.Action("Index", "Employee")';
      });
    });
  });

  $(function () {
    $("#delete").on("click", function (evt) {
      evt.preventDefault();
      $.post("Employee/DeleteEmployee", $("form").serialize(), function () {
        window.location.href = '@Url.Action("Index", "Employee")';
      });
    });
  });
});
