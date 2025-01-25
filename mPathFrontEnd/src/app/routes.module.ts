import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { globalRoutes } from "./modules/global/global.routing";
import { doctorRoutes } from "./modules/doctor/doctor.routing";
import { admissionRoutes } from "./modules/admission/admission.routing";

@NgModule({
  imports: [RouterModule.forChild([
    ...globalRoutes,
    ...doctorRoutes,
    ...admissionRoutes
  ])],
  exports: [ RouterModule]
})

export class RoutesModule {}