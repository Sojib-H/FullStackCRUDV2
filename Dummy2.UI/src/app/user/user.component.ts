import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../Model/User';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  UserInfo: User[];
  constructor(private userService: UserService,private toastr: ToastrService,) {}
  ngOnInit(): void {
    this.reset();
    // this.userService.GetUserByID(2).subscribe((data)=>{
    //   console.log(data);
    // })
  }

  delete(UserID: number) {
    this.toastr.clear();
    this.userService.delete(UserID).subscribe((data) => {
      if (data.ResponseCode == "OK") {
        this.toastr.success(data.ResponseMsg);
        this.reset();
      }
    });
  }

  reset(){
    this.userService.GetAllUser().subscribe((data) => {
      this.UserInfo = data;
    });
  }
}
