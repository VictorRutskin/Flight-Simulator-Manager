import { Component, Input, OnInit } from '@angular/core';
import { ConsoleService } from 'src/app/Services/Console-service/console.service';

@Component({
  selector: 'console',
  templateUrl: './console.component.html',
  styleUrls: ['./console.component.scss']
})
export class ConsoleComponent implements OnInit {
  @Input() input: string | undefined;
  messages: string[] = [];

  constructor(private consoleService: ConsoleService) {}

  ngOnInit() {
    this.consoleService.consoleMessages$.subscribe((newMessage) => {
      this.messages.push(newMessage);
    });
  }

  ngOnChanges() {
    if (this.input) {
      this.messages.push(this.input);
    }
  }
}