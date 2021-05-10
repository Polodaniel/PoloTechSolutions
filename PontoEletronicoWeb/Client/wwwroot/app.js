function TrocarCorFundoSistema() {
    var BODY = document.querySelector('body');
    BODY.removeAttribute("style")
    BODY.classList.remove('bg-blue');
}

function OpenClosePanel(state, id) {
    var panelMultiSelecte = "#" + id;

    if (state === true) {
        $(panelMultiSelecte).show();
    }
    else {
        $(panelMultiSelecte).hide();
    }
}


function ExecutaImpressao() {
    window.print();
}

function FecharModal(ID) {

    var Modal = "#" + ID;

    $(Modal).modal('hide');
}

function FocoInativar() {
    var element = document.getElementById('excluiralert');

    element.scrollIntoView({
        behavior: 'auto',
        block: 'center',
        inline: 'center'
    });
}
