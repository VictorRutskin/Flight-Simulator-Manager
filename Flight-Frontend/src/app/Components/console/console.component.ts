import { Component, Input } from '@angular/core';

@Component({
  selector: 'console',
  templateUrl: './console.component.html',
  styleUrls: ['./console.component.scss']
})
export class ConsoleComponent {
  @Input() input: string | undefined;
  messages: string[] = [];

  ngOnChanges() {
    if (this.input) {
      this.messages.push(this.input);
    }
  }
}