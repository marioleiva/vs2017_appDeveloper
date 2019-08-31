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
        listaDeProductosSinFiltrar:[]
    },
    methods: {
        GetCategoriesFromServer: function () {
            $.get('/api/productmanagement/GetAllCategories')
                .then(categoryArray => {
                    this.categories.push(...categoryArray);
                });
        },
        ResetearInterface: function () {
            this.nombre = '';
            this.descripcion = '';
            this.categoryId = null;
        },
        RegistrarProductoEnElServidor: function () {
                post('/api/productmanagement/RegisterProduct', {
                    Name: this.nombre,
                    Descripcion: this.descripcion,
                    CategoryId: this.categoryId
                })
                .then(newProduct => {
                    this.listaDeProductos.push(newProduct);
                    this.ResetearInterface();
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
app.GetCategoriesFromServer();
app.CargarProductosDelServidor();
