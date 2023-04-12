import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackgroundmusicComponent } from './backgroundmusic.component';

describe('BackgroundmusicComponent', () => {
  let component: BackgroundmusicComponent;
  let fixture: ComponentFixture<BackgroundmusicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BackgroundmusicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BackgroundmusicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
