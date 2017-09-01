import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { PanelModule, EditorModule, InputTextModule, ButtonModule, DataTableModule } from 'primeng/primeng';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmailTemplateService } from './service/EmailTemplate.service';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [        
        BrowserModule,
ReactiveFormsModule,
        FormsModule,
        HttpModule,  
        EditorModule,
        PanelModule,
        ButtonModule,
        InputTextModule,
        BrowserAnimationsModule,
        DataTableModule,
        ...sharedConfig.imports
    ],
    providers: [
        EmailTemplateService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}
