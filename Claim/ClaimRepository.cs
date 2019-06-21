using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public Queue<Claim> ViewClaimQueue()
        {
            return _claimQueue;
        }
        public Claim SeeNextClaim()
        {
            return _claimQueue.Peek();
        }
        public void DealWithClaim()
        {
            _claimQueue.Dequeue();
        }
        public void AddClaim(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }
    }
}
