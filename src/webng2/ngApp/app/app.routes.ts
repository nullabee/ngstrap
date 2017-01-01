import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home/home.component";

export const routes: Routes = [
    { path: "index", component: HomeComponent },
    //{ path: "index", loadChildren: "./app/home/home.module#HomeModule?chunkName=home" },
    { path: "about", loadChildren: "./+about/about.module#AboutModule?chunkName=about" },
    { path: "", redirectTo: "index", pathMatch: "full" }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutesModule { }