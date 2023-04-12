import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ConsoleService } from 'src/app/Services/Console-service/console.service';

@Component({
  selector: 'console',
  templateUrl: './console.component.html',
  styleUrls: ['./console.component.scss']
})
export class ConsoleComponent implements OnInit {
  @ViewChild('console', { static: false })
  consoleElementRef!: ElementRef;
  @Input() input: string | undefined;
  messages: string[] = [];

  constructor(private consoleService: ConsoleService) {}

  ngOnInit() {
    this.consoleService.consoleMessages$.subscribe((newMessage) => {
      this.messages.push(newMessage);
      this.scrollToBottom();
    });
  }
  

  ngOnChanges() {
    if (this.input) {
      this.messages.push(this.input);
    }
  }

  scrollToBottom() {
    setTimeout(() => {
      const consoleElement = this.consoleElementRef.nativeElement;
      consoleElement.scrollTop = consoleElement.scrollHeight;
    }, 0);
  }
  
}