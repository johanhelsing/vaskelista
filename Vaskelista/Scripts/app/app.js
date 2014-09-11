(function () {
    var APIURL = "../../api/";
    var token = window.location.pathname.split("/")[1];
    var taskurl = APIURL + encodeURIComponent(token) + '/tasks/';

    var Task = Backbone.Model.extend({
        urlRoot: taskurl
    });

    var TaskList = Backbone.Collection.extend({
        model: Task,
        url: taskurl
    });

    var tasks = new TaskList();
    tasksGlobal = tasks;
    $(function () {
        tasks.fetch({ data: { week: new Date().toISOString() } }).done(function () { });
        var viewModel = {
            tasks: kb.collectionObservable(tasks, { view_model: kb.ViewModel })
        };
        ko.applyBindings(viewModel, $('main')[0]);
    });

})();
