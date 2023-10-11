import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dialog-box',
  templateUrl: './delete-dialog-box.component.html',
  styleUrls: ['./delete-dialog-box.component.scss']
})
export class DeleteDialogBoxComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    this.type = data.type;
  }

  type: string = '';

  onDeleteClick() {
    this.dialogRef.close(this.data.id);
  }
  onNoClick(): void {
    this.dialogRef.close(null);
  }
}
