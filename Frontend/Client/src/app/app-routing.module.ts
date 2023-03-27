import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { IngredientsComponent } from './ingredients/ingredients.component';
import { MealCollectionsComponent } from './meal-collections/meal-collections.component';
import { MealDetailComponent } from './meals/meal-detail/meal-detail.component';
import { MealListComponent } from './meals/meal-list/meal-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'meals', component: MealListComponent },
      { path: 'meals/:id', component: MealDetailComponent },
      { path: 'mealcollections', component: MealCollectionsComponent },
      { path: 'ingredients', component: IngredientsComponent },
    ]
  },
  { path: 'errors', component: TestErrorComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
