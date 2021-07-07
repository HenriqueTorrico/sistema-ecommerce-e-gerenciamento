jQuery(function ($) {
    $("input[name = 'cep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("http://apps.widenet.com.br/busca-cep/api/cep.json", { code: cep_code }, function (result) {
            if (result.status != 1) {
                alert(result.message || "CEP não encontrado");
                return;
            }
            $("input[name = 'cep']").val(result.code);
            $("input[name = 'cidade']").val(result.city);
            $("input[name = 'bairro']").val(result.district);
            $("input[name = 'logradouro']").val(result.address);
            $("input[name = 'estado']").val(result.state);
        });
    });
});