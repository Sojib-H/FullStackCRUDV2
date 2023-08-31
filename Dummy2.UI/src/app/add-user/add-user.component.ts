import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../Model/User';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
})
export class AddUserComponent implements OnInit {
  User: User = new User();
  btnSave: string;
  constructor(
    private userService: UserService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.reset();
  }

  Save() {
    this.toastr.clear();
    if (this.ValidationFun() == true) {
      this.userService.AddUser(this.User).subscribe((data) => {
        if (data.ResponseCode == 'OK') {
          this.toastr.success(data.ResponseMsg);
          this.router.navigate(['']);
        } else {
          this.toastr.warning(data.ResponseMsg);
          this.reset();
        }
      });
    }
  }

  onKeyDownEventamtMobileNo(e: KeyboardEvent) {
    if (
      // Allow: Delete, Backspace, Tab, Escape, Enter
      [46, 8, 9, 27, 13].indexOf(e.keyCode) !== -1 ||
      (e.keyCode === 65 && e.ctrlKey === true) || // Allow: Ctrl+A
      (e.keyCode === 67 && e.ctrlKey === true) || // Allow: Ctrl+C
      (e.keyCode === 86 && e.ctrlKey === true) || // Allow: Ctrl+V
      (e.keyCode === 88 && e.ctrlKey === true) || // Allow: Ctrl+X
      (e.keyCode === 65 && e.metaKey === true) || // Cmd+A (Mac)
      (e.keyCode === 67 && e.metaKey === true) || // Cmd+C (Mac)
      (e.keyCode === 86 && e.metaKey === true) || // Cmd+V (Mac)
      (e.keyCode === 88 && e.metaKey === true) || // Cmd+X (Mac)
      (e.keyCode >= 35 && e.keyCode <= 39) // Home, End, Left, Right
    ) {
      return; // let it happen, don't do anything
    }
    // Ensure that it is a number and stop the keypress
    if (
      (e.shiftKey || e.keyCode < 48 || e.keyCode > 57) &&
      (e.keyCode < 96 || e.keyCode > 105)
    ) {
      e.preventDefault();
    }
  }

  ValidationFun(): Boolean {
    this.toastr.clear();
    if (this.User.Name == undefined || this.User.Name == '') {
      document.getElementById('Name')?.focus();
      this.toastr.warning('Please Enter Name');
      return false;
    } else if (this.User.Mobile == undefined || this.User.Name == '') {
      document.getElementById('Mobile')?.focus();
      this.toastr.warning('Please Enter Mobile');
      return false;
    } else if (this.User.Email == undefined || this.User.Email == '') {
      document.getElementById('Email')?.focus();
      this.toastr.warning('Please Enter Email');
      return false;
    } else if (this.User.Address == undefined || this.User.Address == '') {
      document.getElementById('Address')?.focus();
      this.toastr.warning('Please Enter Address');
      return false;
    } else {
      return true;
    }
  }

  reset() {
    this.User = new User();
    this.btnSave = 'Save';
  }
}
