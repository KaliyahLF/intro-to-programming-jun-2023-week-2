import { CurrencyPipe } from "@angular/common";
import { Component, Signal, signal } from "@angular/core";
import { BankAccount } from "../services/bank-account.service";



@Component({
    selector: 'app-account',
    template: `
<section>
<span>Your balance is {{balance() | currency}}</span>
</section>
<section>
<label>Amount: <input type="number" #amount /></label>
</section>
<section>
<button class="btn btn-primary" (click)="deposit(amount)">Deposit</button>
<button (click)="withdraw(amount)">Withdraw</button>
</section>

    `,
    imports: [CurrencyPipe],
    standalone: true
})
export class BankAccountComponent {




    private account: BankAccount;
    balance: Signal<number>;



    constructor(account: BankAccount) {
        this.account = account;
        this.balance = account.getBalance();
    }



    deposit(amount: HTMLInputElement) {
        this.account.makeDeposit(amount.valueAsNumber);
        amount.value = '';
        amount.focus();
    }



    withdraw(amount: HTMLInputElement) {
        this.account.makeWithdrawal(amount.valueAsNumber);
        amount.value = '';
        amount.focus();
    }
}