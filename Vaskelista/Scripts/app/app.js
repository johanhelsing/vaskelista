(function () {
    var APIURL = "../../api/";
    var token = window.location.pathname.split("/")[1];
    var taskurl = APIURL + encodeURIComponent(token) + '/tasks/';

    var Task = Backbone.Model.extend({
        urlRoot: taskurl
    });

    var TaskViewModel = kb.ViewModel.extend({
        constructor: function (model, options) {
            this.expired = ko.computed(function () { return model.get('start')<new Date().toISOString(); }, this);
            kb.ViewModel.prototype.constructor.apply(this, arguments);
        }
    });

    var TaskList = Backbone.Collection.extend({
        model: Task,
        url: taskurl
    });

    var tasks = new TaskList();
    tasksGlobal = tasks;
    $(function () {
        tasks.fetch({ data: { week: new Date().toISOString() } }).done(function () { });

        var sort_attribute = ko.observable('start');

        var viewModel = {
            tasks: kb.collectionObservable(tasks, {
                view_model: TaskViewModel,
                sort_attribute: sort_attribute
            })
        };

        ko.applyBindings(viewModel, $('main')[0]);
    });

})();
