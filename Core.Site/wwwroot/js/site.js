function ValidacoesEvento() {
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    $('#DataInicio').datepicker(
        {
            todayHighlight: true,
            format: "dd/mm/yyyy",
            startDate: "today",
            language: "pt-BR",
            orientation: "bottom right",
            autoclose: true,
        });

    $('#DataFim').datepicker(
        {
            todayHighlight: true,
            format: "dd/mm/yyyy",
            startDate: "today",
            language: "pt-BR",
            orientation: "bottom right",
            autoclose: true,
        });

    // Validações de exibição do endereço
    $(document).ready(function () {
        var $input = $("#Online");
        var $gratuito = $("#Gratuito");
        MostrarEndereco();
        HabilitarCampoGratuito();

        $input.click(function () {
            MostrarEndereco();
        });

        $gratuito.click(function () {
            HabilitarCampoGratuito();
        });

        function MostrarEndereco() {
            if ($input.is(":checked"))
                $("#EnderecoForm").hide();
            else
                $("#EnderecoForm").show();
        }

        // Campo valor se for gratuito ou não
        function HabilitarCampoGratuito() {
            if ($gratuito.is(":checked")) {
                $("#Valor").prop("disabled", true);
            } else {
                $("#Valor").prop("disabled", false);
            }
        }

    });

}

function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#enderecoModalContent').load(this.href,
                        function () {
                            $('#enderecoModal').modal({
                                keyboard: true
                            }, 'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#enderecoModal').modal('hide');
                            $('#enderecoAlvo').load(result.url);
                        } else {
                            $('#enderecoModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });

}