import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from  '@angular/platform-browser/animations';
import { MatTabsModule} from '@angular/material/tabs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {MatListModule} from '@angular/material/list';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatChipsModule} from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { DxTagBoxModule, DxAccordionModule, DxDateBoxModule  } from 'devextreme-angular';



import { AppComponent } from './app.component';
import { TabsComponent } from "./components/UI/tabs/tabs.component";
import { BaseNotesComponent } from './components/notes/base-notes/base-notes.component';
import { NoteDetailsComponent } from "./components/notes/note-details/note-details.component";
import { NotesListComponent } from "./components/notes/notes-list/notes-list.component";
import { DialogBoxComponent } from './components/UI/dialog-box/dialog-box.component';
import { DeleteDialogBoxComponent } from './components/UI/delete-dialog-box/delete-dialog-box.component';
import { TagsListComponent } from './components/tags/tags-list/tags-list.component';
import { NoticeComponent } from './components/notices/notice/notice.component';
import { NoticeDialogBoxComponent } from './components/UI/notice-dialog-box/notice-dialog-box.component';

@NgModule({
    declarations: [
        AppComponent,
        BaseNotesComponent,
        NoteDetailsComponent,
        NotesListComponent,
        TabsComponent,
        DialogBoxComponent,
        DeleteDialogBoxComponent,
        TagsListComponent,
        NoticeComponent,
        NoticeDialogBoxComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        NgbModule,
        BrowserAnimationsModule,
        HttpClientModule,
        MatTabsModule,
        MatListModule,
        MatDividerModule,
        MatButtonModule,
        MatChipsModule,
        MatIconModule,
        MatMenuModule,
        MatDialogModule,
        MatInputModule,
        ReactiveFormsModule,
        FormsModule,
        MatAutocompleteModule,
        DxTagBoxModule,
        DxAccordionModule,
        DxDateBoxModule,
    ]
})
export class AppModule { }
