var app = new Vue({
    el: '#app',
    data: {
        categories: [],
        categoryId: null,
        nombre: '',
        descripcion: '',
        listaDeProductos:[]
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
                });
        }
    }
})
app.GetCategoriesFromServer();
app.CargarProductosDelServidor();
