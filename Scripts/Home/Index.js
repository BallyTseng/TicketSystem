

var app = new Vue({
    el: '#app',
    data: {
        list: null,
        form: {
            id:'',
            summary: '',
            description: ''
        }
    },

    mounted() {
        baseInstance.get('/Query')
            .then(response => {
                this.list = response.data;
            });
    },

    methods: {

        Save() {
            baseInstance.post('/Update', this.form)
                .then(response => {
                    this.list = response.data;
                    $.notify("success", "success", { position: "bottom" });
                })
                .catch(function (error) {
                    $.notify("error", "error", { position: "bottom" });
                });

            $('#editModal').modal('hide');
            Reset();
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
                    $.notify("success", "success", { position: "bottom" });
                })
                .catch(function (error) {
                    $.notify("error", "error", { position: "bottom" });
                });
        },

        Delete(item) {
            baseInstance.post('/Delete', item)
                .then(response => {
                    this.list = response.data;
                    $.notify("success", "success", { position: "bottom" });
                })
                .catch(function (error) {
                    $.notify("error", "error", { position: "bottom" });
                });
        }

    }
});