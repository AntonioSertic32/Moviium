import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowKorisnikComponent } from './show-korisnik.component';

describe('ShowKorisnikComponent', () => {
  let component: ShowKorisnikComponent;
  let fixture: ComponentFixture<ShowKorisnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowKorisnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowKorisnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
