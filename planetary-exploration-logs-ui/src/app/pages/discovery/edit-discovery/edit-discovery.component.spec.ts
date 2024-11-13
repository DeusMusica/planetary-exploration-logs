import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDiscoveryComponent } from './edit-discovery.component';

describe('EditDiscoveryComponent', () => {
  let component: EditDiscoveryComponent;
  let fixture: ComponentFixture<EditDiscoveryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditDiscoveryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditDiscoveryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
