// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("body").off("click", "#btnCreate").on("click", "#btnCreate", function (e) {
	e.preventDefault();
	$('#dialogContent').load(this.href, function () {
		$('#dialogDiv').modal({
			keyboard: true
		}, 'show').on('show.bs.modal', function () {
			setTimeout(function () {
			}, 500);
		});
		bindForm(this);
	});
	return false;
});

$("body").off("click", "#btnShow").on("click", "#btnShow", function (e) {
	e.preventDefault();
	$('#dialogContent').load(this.href, function () {
		$('#dialogDiv').modal({
			keyboard: true
		}, 'show').on('show.bs.modal', function () {
			setTimeout(function () {
			}, 500);
		});
		bindForm(this);
	});
	return false;
});

function bindForm(dialog) {
	$('form', dialog).submit(function (e) {
		var mform = this;
		$.ajax({
			url: mform.action,
			type: mform.method,
			data: $(mform).serialize(),
			success: function (result) {
				$('#dialogDiv').modal('hide');
				if (result.success) {
					swal({
						title: "Транзакция была успешной!",
						type: "success",
						closeOnClickOutside: false,
						delay: 500
					});
					setTimeout(function () {
						location.reload();
					}, 1200);
				}
				else if (!result.success)
				{
					swal({
						title: "Что то пошло не так!",
						type: "error",
						closeOnClickOutside: false,
						showConfirmButton: false,
						delay: 1500
					}, setTimeout(function () {
						swal.close();
					}, 2000));
				}
			}
			
		});
		return false;
	});
}