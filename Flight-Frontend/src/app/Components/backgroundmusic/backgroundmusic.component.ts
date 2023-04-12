import { Component } from '@angular/core';

@Component({
  selector: 'backgroundmusic',
  templateUrl: './backgroundmusic.component.html',
  styleUrls: ['./backgroundmusic.component.scss']
})
export class BackgroundmusicComponent {
  private bgMusic: HTMLAudioElement;
  isPlaying: boolean = false; // Track the current state of audio playback

  constructor() {
    this.bgMusic = new Audio();
    this.bgMusic.src = 'assets/background-music.mp3'; // Update the relative path to your audio file
    this.bgMusic.load(); // Load the audio file
    this.bgMusic.loop = true; // Set the loop attribute to true
  }

  toggleMusic() {
    if (this.isPlaying) {
      this.bgMusic.pause(); // Pause the audio file
    } else {
      this.bgMusic.play(); // Play the audio file
    }
    this.isPlaying = !this.isPlaying; // Toggle the playback state
  }
}