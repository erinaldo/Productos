var maintenanceApp = angular.module('maintenanceApp', ['ngRoute']);

maintenanceApp
      .config(["$provide", function ($provide) {
          var rootUrl = $("#linkRoot").attr("href");

          $provide.constant('rootUrl', rootUrl);
      }])