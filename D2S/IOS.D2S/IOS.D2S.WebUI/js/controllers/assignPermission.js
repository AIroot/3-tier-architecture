(function () {
    var permissionCtrl = function ($rootScope, $scope, $location, util, authorizationSvc) {

       // permissionByRole();
        

        var user = JSON.parse(localStorage.getItem("user"));
        console.log(user.BranchId);
        $scope.branchID = user.BranchId;

        $scope.showTree = false;
        $scope.loadingPermissions = false;

        $scope.featureSelected = 7;
        var operations = [];


        getRolesByBranch();
        getOperationsByBranch();


        function getRolesByBranch() {
            $scope.loadingRoles = true;
            authorizationSvc.getRolesByBranch($scope.branchID, function (data) {


                $scope.roles = data;
                $scope.loadingRoles = false;
                for (var i = 0; i < $scope.roles.length; i++) {
                    if ($scope.roles[i].Name = 'Administrator') {

                        $scope.adminRoleID = $scope.roles[i].Id;
                        $scope.roles.splice(i, 1);
                        
                    }
                }

            });

        }

        function getOperationsByBranch() {

            authorizationSvc.getOperationsByBranch($scope.branchID, function (data) {
                console.log(data);
                $scope.operations = data;

            });

        }

       function permissionByRole(roleId){

           authorizationSvc.getPermissionByRole(roleId,$scope.branchID, function (roleData) {
              
                    
                   authorizationSvc.getPermissionByRole($scope.adminRoleID, $scope.branchID, function (data) {


                       
                       $scope.modules = data;
                       $scope.showTree = true;
                       $scope.loadingPermissions = false;

                      

                           for (var i = 0; i < $scope.modules.length; i++) {
                               $scope.modules[i].btn_text = '+';
                               $scope.modules[i].show = false;
                               $scope.modules[i].RoleId = roleId;
                               $scope.modules[i].branchId = $scope.BranchId;



                               for (var j = 0; j < $scope.modules[i].Features.length; j++) {
                                   var feature = $scope.modules[i].Features[j];

                                   feature.IsActive = false;
                                   feature.Operation = {};


                               

                                   for (var k = 0; k < $scope.operations.length; k++) {
                                 
                                       $scope.operations[k].checked = false;
                                       $scope.operations[k].IsActive = false;
                                   }

                                   feature.operations = angular.copy($scope.operations);
                               }
                           }


                     

                           if (roleData.length !== 0)
                           {

                               $scope.roleModules = roleData;
                               console.log($scope.roleModules);

                               for (var i = 0; i < $scope.modules.length; i++) {

                                   angular.forEach($scope.roleModules, function (roleModule, key) {

                                       if ($scope.modules[i].Id == roleModule.Id) {

                                           $scope.modules[i].btn_text = '+';
                                           $scope.modules[i].show = false;
                                           $scope.modules[i].RoleId = roleId;
                                           $scope.modules[i].branchId = $scope.BranchId;



                                           for (var j = 0; j < $scope.modules[i].Features.length; j++)
                                           {

                                               angular.forEach(roleModule.Features, function (roleFeature, key) {
                                                   var feature = $scope.modules[i].Features[j];

                                                   if (feature.Id == roleFeature.Id)
                                                   {

                                                       feature.IsActive = true;
                                                       feature.Operation = {};



                                                       for (var k = 0; k < $scope.operations.length; k++)
                                                       {

                                                           $scope.operations[k].checked = false;
                                                           $scope.operations[k].IsActive = false;

                                                           if(roleFeature.Operation.Id == $scope.operations[k].Id )
                                                           {
                                                               $scope.operations[k].checked = true;
                                                           }
                                                       }

                                                       feature.operations = angular.copy($scope.operations);
                                                       
                                                   }




                                               });
                                           }
                                       }

                                   });
                               }


                           }
                           //$scope.modules[0].Features[1].IsActive = true;
                      
                   

                   });

             
               

           });
            
            
          

       };

       $scope.toggleModule = function (module) {
           if (module.btn_text == '+') {
               module.btn_text = '-';
           } else {
               module.btn_text = '+';
           }
           
           module.show = !module.show;
       }

       $scope.editClick = function (role) {
           $scope.loadingPermissions = true;
           $scope.assignPermissionSuccess = false;
           $scope.showTree = false;
           permissionByRole(role.Id);
       }

       $scope.assignPermissions = function () {

           var rolePrivilegeRequest = {
               moduleList: $scope.modules
           }

           console.log($scope.modules);
           authorizationSvc.assignPermissions(rolePrivilegeRequest, function (data) {
               if (data == true) {
                   $scope.assignPermissionSuccess = true;
               }
               

           });
       }

       $scope.checkFeature = function (feature) {
           //feature.IsActive = !feature.IsActive;
           console.log(feature.IsActive);
           console.log(feature);
           var operations = feature.operations;
           for (var j = 0; j < operations.length; j++) {
               operations[j].IsActive = false;
           }
       }

       $scope.operationClick = function (feature, operation) {
           feature.Operation = operation;
       }



    };

    permissionCtrl.$inject = ['$rootScope', '$scope', '$location', 'util', 'authorizationSvc'];
    angular.module('d2cApp').controller('permissionCtrl', permissionCtrl);
}());