var app = new Vue({
    el: '#app',
    data: {
        categories: [],
        categoryId: null,
        categoryIdFilter:0,
        nombre: '',
        nombreFiltro:'',
        descripcion: '',
        listaDeProductos: [],
        listaCanales: [],
        listaDeProductosSinFiltrar:[]
    },
    methods: {
        GetCanalesFromServer: function () {
            $.get('/api/canalesManagement/GetAllCanales')
                .then(canalesArray => {
                    this.listaCanales.push(...canalesArray);
                });
        },
        GetCategoriesFromServer: function () {
            $.get('/api/productmanagement/GetAllCategories')
                .then(categoryArray => {
                    this.categories.push(...categoryArray);
                });
        },
        
        CargarProductosDelServidor: function () {
            $.get('/api/productmanagement/GetAllProducts')
                .then(productosDelServidor => {
                    this.listaDeProductos.push(...productosDelServidor)
                    this.listaDeProductosSinFiltrar.push(...productosDelServidor);
                });
        },
        cambioElFiltro: function () {
            if (this.categoryIdFilter == 0) {
                this.listaDeProductos = [];
                this.CargarProductosDelServidor();
            }
            else {
                $.get('/api/productmanagement/GetProductByCategoryId?categoryId=' + this.categoryIdFilter)
                    .then(productosDelServidor => {
                        this.listaDeProductos = [];
                        this.listaDeProductos.push(...productosDelServidor)
                    });
            }
        },
        ActivarFiltro: function () {
            if (this.nombreFiltro.length > 0) {
                this.listaDeProductos = [];
                this.listaDeProductos = this.listaDeProductosSinFiltrar.filter(x => {
                    return x.Name.includes(this.nombreFiltro);
                });
            }
            else {
                this.listaDeProductos = this.listaDeProductosSinFiltrar;
            }

        }
    }
})
app.GetCanalesFromServer();
//app.CargarProductosDelServidor();
