import { Component, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { PanelModule, EditorModule, InputTextModule, ButtonModule,SharedModule } from 'primeng/primeng';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Message, LazyLoadEvent } from 'primeng/components/common/api';
import { Email, IEmail } from '../../models/Email';
import { ApiResponse } from '../../models/response';
import { EmailTemplateService } from '../../service/EmailTemplate.service';
import { Query } from "../../models/query";
import { Quill } from 'quill/dist/quill';
import { Subject } from 'rxjs/Subject';
type Severities = 'success' | 'info' | 'warn' | 'error';

@Component({
    selector: 'EmailSettings',
    templateUrl:'./EmailSettings.component.html'
        
})
export class EmailSettingsComponent{
    title = "Format Email";
    msgs: Message[] = [];
    emailform: FormGroup;
    emailformEdit: FormGroup;
    editedRowIndex: number;
    apiResponse: ApiResponse;
    Emails: IEmail[];
    email: IEmail = new Email();
    emailval: IEmail = new Email();
    displayDialog: boolean = false;
    EditID: number;
    submitted: boolean;

    filterBy: string;
    query: Query;
    totalRecords: number;
    currentsortOrder: number;
    currentsortField: string;
    currentFirst: number;
    currentRow: number;

    emails: any[];
    posts: any[];
    private url = "api/EmailSetting";
    notificationChange: Subject<Object> = new Subject<Object>();
    constructor(private fb: FormBuilder, private http: Http,private emailTemplateService:EmailTemplateService) {
        
    }

    ngOnInit() {
        this.emailform = this.fb.group({
            'salutation': new FormControl('', Validators.required),
            'subject': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)])),
            'description': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)])),
            'signature': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)]))

        });

        this.emailformEdit = this.fb.group({
            'salutation': new FormControl('', Validators.required),
            'subject': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)])),
            'description': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)])),
            'signature': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)]))

        });
    }

    loadDataLazy(event: LazyLoadEvent) {

        setTimeout(() => {
            this.loadData(event.sortOrder, event.sortField, event.first, event.rows);
        }, 250);
    }

    loadData(sortOrder: number, sortField: string, first: number, rows: number) {
        this.currentsortOrder = sortOrder;
        this.currentsortField = sortField;
        this.currentFirst = first;
        this.currentRow = rows;
        this.query = null;
        if (sortField == undefined)
            sortField = "salutation";


        this.query = new Query(sortField, sortOrder == 1 ? true : false, (first + 10) / 10, rows);
        console.log(this.query);
        this.emailTemplateService.getEmail(this.query)
            .subscribe(data => {
                this.apiResponse = data;
                this.totalRecords = this.apiResponse.totalRecords;
                this.emails = <IEmail[]>this.apiResponse.data;

            });
    }

    onSubmit(value: string) {
        this.submitted = true;
        this.msgs = [];
        this.email = this.emailval;
        if (this.email.id == null) {

            this.emailTemplateService.create(this.email).subscribe(res => {
                this.apiResponse = res;
                if (res.success == false)
                    this.notify('error', res.message, res.result as string);
                else
                    this.notify('success', res.message, res.result as string);
                this.loadData(this.currentsortOrder, this.currentsortField, this.currentFirst, this.currentRow);
                this.clear();

            });

        }
        else {

            this.emailTemplateService.update(this.email).subscribe(res => {
                this.displayDialog = false;
                this.apiResponse = res;
                if (res.success == false)
                    this.notify('error', res.message, res.result as string);
                else
                    this.notify('info', res.message, res.result as string);
                this.loadData(this.currentsortOrder, this.currentsortField, this.currentFirst, this.currentRow);
                this.clear();
            });
        }


    }
    delete(event): void {
        this.email = this.emails[event];
        if (this.email != null) {
            this.emailTemplateService.delete(this.email).subscribe(res => {

                this.apiResponse = res;
                if (res.success == false)
                    this.notify('error', res.message, res.result as string);
                else
                    this.notify('info', res.message, res.result as string);
                this.loadData(this.currentsortOrder, this.currentsortField, this.currentFirst, this.currentRow);
                this.clear();
            });
        }
    }

    clear() {

        this.msgs = [];
        this.email = new Email();
        this.emailform.reset();

    }


    edit(event) {
        this.emailval = this.emails[event];
    }

    notify(severity: Severities, summary: string, detail: string) {
        this.notificationChange.next({ severity, summary, detail });
    }

    get diagnostic() { return JSON.stringify(this.emailform.value); }
   
    }



