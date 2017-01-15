import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { TodoComponent } from './components/todo/todo.component';

import { TodoService } from './components/todo/todo.service';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        TodoComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: TodoComponent },
            { path: '**', redirectTo: '' }
        ])
    ],
    providers: [ TodoService ]
})
export class AppModule {
}
