import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { INote } from 'src/app/models/note';
import { NoteService } from 'src/app/services/notes/note.service';
import { DialogBoxComponent } from '../../UI/dialog-box/dialog-box.component';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrls: ['./note-details.component.scss'],
})
export class NoteDetailsComponent implements OnInit {
  @Input() note: INote;
  targetDate: Date = new Date('01-01-0001 00:00');

  constructor(private noteService: NoteService, private tagService: TagService, public dialog: MatDialog) {}


  openEditDialog(note: INote): void {
    let dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.disableClose = true;
    dialogConfig.data = note;

    const dialogRef = this.dialog.open(DialogBoxComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((data) => {
      if(data && data.noteId) this.updateData(data);
    });
  }

  updateData(updatedNote: INote) {
    this.noteService.updateNote(updatedNote).subscribe((data)=>
    {
      if(updatedNote.tags) {
        updatedNote.noteId = data.noteId;
        this.tagService.bindTagsToNote(updatedNote).subscribe();
        data.tags = updatedNote.tags;
      }
      this.note = data;
    });
  }
  ngOnInit () {
    
  }
}
