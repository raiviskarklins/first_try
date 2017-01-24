//Execute JavaScript on page load
$(function () {
	$("#userNumber, #endNumber").intlTelInput({
		responsiveDropdown: true,
		autoFormat: true
	});
	var $form = $("#contactform"),
		$submit = $("#contactform input[type=submit]");

	//Intercept form submission
	$form.on("submit", function(e)){
	//Prevent form submission and repeat clicks
		e.preventDefault();
		$submit.attr("disabled", "disabled");

		//Submit the form via AJAX
		$.post("Home/Call", $form.serialize(), null, "json")
		.done(function (data) {
			alert(data.message);
			if (data.success) {
				$form.reset();
			}
		}).fail(function () {
			alert("There's some kind of problem with the call.");
		}).always(function ()) {
			$submit.removeAttr("disabled");
		});
	});
});