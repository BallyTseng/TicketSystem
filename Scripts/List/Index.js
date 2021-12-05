

var app = new Vue({
    el: '#app',
    data: {
        list: [],
        form: {
            id:'',
            summary: '',
            description: ''
        },
        role: {
            update:false,
            delete: false,
            create: false,
            resolve: false
        }
    },
    computed: {
        totalcount: function () {
            return  this.list.length;
        },
        resolvecount: function () {
            return this.list.filter(x => x.resolve).length;
        },
        unresolvecount: function () {
            return  this.list.filter(x => x.resolve === false).length;
        }
    },

    mounted() {
        baseInstance.get('/Query')
            .then(response => {
                this.list = response.data;
            });

        baseInstance.get('/Role')
            .then(response => {
                this.role = response.data;
            });
    },

    methods: {

        Save() {

            let form = $("#trickform");
            if (form[0].checkValidity() === true) {
                baseInstance.post('/Update', this.form)
                    .then(response => {
                        this.list = response.data;
                        $.notify("success", "success");
                    })
                    .catch(function (error) {
                        $.notify("error", "error");
                    });

                $('#editModal').modal('hide');
                this.Reset();
            }
        },

        Reset() {
            this.form.id = '';
            this.form.summary = '';
            this.form.description = '';
        },

        Edit(item) {
            this.form = Object.assign({}, item);
            $('#editModal').modal('show');
        },

        UpdateResolve(item) {
            baseInstance.post('/UpdateResolve', { id: item.id, resolve: (item.resolve === 'true')})
                .then(response => {
                    this.list = response.data;
                    $.notify("success", "success");
                })
                .catch(function (error) {
                    $.notify("error", "error");
                });
        },

        Delete(item) {
            baseInstance.post('/Delete', { id: item.id })
                .then(response => {
                    this.list = response.data;
                    $.notify("success", "success");
                })
                .catch(function (error) {
                    $.notify("error", "error", { position: "bottom" });
                });
        }

    }
});