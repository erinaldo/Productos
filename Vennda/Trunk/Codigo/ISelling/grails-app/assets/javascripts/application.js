// This is a manifest file that'll be compiled into application.js.
//
// Any JavaScript file within this directory can be referenced here using a relative path.
//
// You're free to add application-wide JavaScript to this file, but it's generally better 
// to create separate JavaScript files as needed.
//
//= require jquery
//= require_tree .
//= require_self

/*if (typeof jQuery !== 'undefined') {
	(function($) {
		$(document).ajaxStart(function(){
			$('#spinner').fadeIn();
		}).ajaxStop(function(){
			$('#spinner').fadeOut();
		});
	})(jQuery);

	Date.prototype.plus = function(days) {
		var dat = new Date(this.valueOf());
		dat.setDate(dat.getDate() + days);
		return dat;
	};

	function addValorImpuestoForm(parent, indice) {
		console.log("indice",indice);
		$.ajax({
			url: globalUrls['ajax.addValorImpuestoForm'],
			dataType: 'html',
			context:parent,
			method:'POST',
			data: {indice: indice}
		})
		.done(function(data, textStatus, jqXHR){
			//console.log(data);
			//console.log($(this));
			$(this).append(data);
		})
		.fail(function( jqXHR, textStatus, errorThrown ) {
			alert(errorThrown);
		});
	};

	function removeValorImpuesto(eventObject) {

		if(!confirm(globalMessages['default.button.delete.confirm.message'])){
			return;
		}

		var currentTarget = eventObject.currentTarget;
		var _currentTargetParent = $(currentTarget).parents(".valoresImpuestoInstance");
		var valorImpuestoId = $(currentTarget).data('valoresimpuestoid');

		_currentTargetParent.toggle(false);//Oculta el elemento

		if(!valorImpuestoId) {
			_currentTargetParent.remove();
			return;
		}

		$.ajax({
			url:globalUrls['ajax.removeValorImpuesto'],
			dataType: 'json',
			context:_currentTargetParent,
			method:'POST',
			data: { id: valorImpuestoId }
		})
		.done(function(data, textStatus, jqXHR){
			if(jqXHR.status == 204) {
				_currentTargetParent.remove();

				var previousInicioDatepicker = $('#panelBodyImpuesto div:nth-last-child(1) input[name$="inicio"]');
				if(previousInicioDatepicker.length > 0){
					previousInicioDatepicker.attr("readonly",false);
					$(previousInicioDatepicker[0]).datepicker({
						dateFormat: "dd-mm-yy",
						minDate: $.datepicker.formatDate('dd-mm-yy',$(previousInicioDatepicker[0]).val(startDate)),
						onSelect: function () {
							var startDate = $.datepicker.formatDate('dd-mm-yy',$(this).datepicker('getDate').plus(-1));
							if(previousFinDatepicker.length > 0){
								$(previousFinDatepicker[0]).val(startDate);
							}
						}
					});
				}
				var previousFinDatepicker = $('#panelBodyImpuesto div:nth-last-child(1) input[name$="fin"]');
				if(previousFinDatepicker.length > 0){
					$(previousFinDatepicker[0]).datepicker('setDate',"01-01-9999");
				}
				var previousBorrar = $('#panelBodyImpuesto div:nth-last-child(1) input[name$="Borrar"]:not(:visible)');
				if(previousBorrar.length > 0){
					$(previousBorrar[0]).show();
				}

			}
		})
		.fail(function( jqXHR, textStatus, errorThrown ) {
			alert(errorThrown);
			_currentTargetParent.toggle(true);
		});
	};
	
	function debounce(func, wait, immediate) {
		var timeout;
		return function() {
			var context = this, args = arguments;
			var later = function() {
				timeout = null;
				if (!immediate) func.apply(context, args);
			};
			var callNow = immediate && !timeout;
			clearTimeout(timeout);
			timeout = setTimeout(later, wait);
			if (callNow) func.apply(context, args);
		};
	};
}*/