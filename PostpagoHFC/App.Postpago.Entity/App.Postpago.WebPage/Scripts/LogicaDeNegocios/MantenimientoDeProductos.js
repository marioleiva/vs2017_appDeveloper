var app = new Vue({
    el: '#app',
    data: {
        claroCanales: [],
        claroCanalesPlus: [],
        claroTotalCanales: [],
        categories: [],
        categoryId: null,
        categoryIdFilter: 0,
        nombre: '',
        nombreFiltro: '',
        descripcion: '',
        listaDeProductos: [],
        listaDeProductosSinFiltrar:[]
    },
    methods: {
        CargarProductosDelServidor: function () {
            $.get('/CanalesServidor')
                .then(productosDelServidor => {
                    this.listaDeProductos.push(...productosDelServidor)
                   // this.listaDeProductosSinFiltrar.push(...productosDelServidor);
                });
        }
    }
})
//app.GetCategoriesFromServer();
//app.CargarProductosDelServidor();
