"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
// Imports
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var LoanComponent = (function () {
    function LoanComponent(route) {
        this.route = route;
        this.items = [5];
        //this.router = router;
    }
    // Load data ones componet is ready
    LoanComponent.prototype.ngOnInit = function () {
        //this.exists = true;
        this.items.length = 5;
    };
    LoanComponent.prototype.ngOnDestroy = function () {
        // Clean sub to avoid memory leak
    };
    LoanComponent = __decorate([
        core_1.Component({
            templateUrl: 'angular/app/loan/loan.html',
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof router_1.Router !== 'undefined' && router_1.Router) === 'function' && _a) || Object])
    ], LoanComponent);
    return LoanComponent;
    var _a;
}());
exports.LoanComponent = LoanComponent;
//# sourceMappingURL=loan.component.js.map