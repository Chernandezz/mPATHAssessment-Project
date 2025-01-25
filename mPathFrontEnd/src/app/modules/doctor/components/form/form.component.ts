import { Component, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { SharedModule } from '../../../global/shared.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss',
})
export class FormComponent implements OnInit {
  formGroup!: FormGroup;

  readonly dialogRef = inject(MatDialogRef<FormComponent>);
  data = inject(MAT_DIALOG_DATA);

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    console.log(this.data);
    this.initForm();
  }

  cancel() {
    this.dialogRef.close();
  }
  save() {}

  initForm() {
    this.formGroup = this.fb.group({
      firstName: [{ value: '', disabled: false }, [Validators.required]],
      lastName: [{ value: '', disabled: false }, [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      active: [true, [Validators.required]],
    });
  }
}
