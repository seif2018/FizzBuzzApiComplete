import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FizzBuzzService } from './fizzbuzz.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './app.component.html'
})
export class AppComponent {
  result: string[] = [];
  errorMessage = '';
  loading = false;

  readonly form = this.formBuilder.nonNullable.group({
    int1: [3, [Validators.required, Validators.min(1)]],
    int2: [5, [Validators.required, Validators.min(1)]],
    limit: [15, [Validators.required, Validators.min(1), Validators.max(100000)]],
    str1: ['Fizz', [Validators.required]],
    str2: ['Buzz', [Validators.required]]
  });

  constructor(private readonly formBuilder: FormBuilder, private readonly fizzBuzzService: FizzBuzzService) {}

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.loading = true;
    this.errorMessage = '';
    this.result = [];

    this.fizzBuzzService.generate(this.form.getRawValue()).subscribe({
      next: result => { this.result = result; this.loading = false; },
      error: error => { this.errorMessage = error?.error?.error ?? 'Une erreur est survenue.'; this.loading = false; }
    });
  }
}
