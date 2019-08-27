var app = new Vue({
    el: '#app',
    data: {
        categories: [],
        categoryId: null,
        categoryIdFilter: 0,
        nombre: '',
        nombreFiltro: '',
        descripcion: '',
        listaDeProductos: [],
        listaDeProductosSinFiltrar: []
    },
    methods: {
        ResetearInterface: function () {
            this.Description = '';
            this.complete = '';
            this.SheduledFor = null;
        },
        RegistrarSheduler: function () {
            post('/api/ShedulerTask/RegisterSheduler', {
                Description: this.Description,
                complete: this.complete,
                SheduledFor: this.SheduledFor
            })
                .then(newProduct => {
                    this.listaDeProductos.push(newProduct);
                    this.ResetearInterface();
                });
        },
        CargarProductosDelServidor: function () {
            $.get('/api/ShedulerTask/GetAllShedulerTask')
                .then(productosDelServidor => {
                    this.listaDeProductos.push(...productosDelServidor)
                    this.listaDeProductosSinFiltrar.push(...productosDelServidor);
                });
        },
    }
})
//app.GetCategoriesFromServer();
//app.CargarProductosDelServidor();
