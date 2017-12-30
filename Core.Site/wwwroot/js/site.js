function ValidacoesEvento() {
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
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

}