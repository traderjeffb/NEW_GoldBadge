using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claims = new Queue<Claims>();

        //CRUD

        //CREATE
        public bool AddNewClaim(Claims content)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(content);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ
        public Queue<Claims> GetAllClaims()
        {
            return _claims;
        }


        //DELETE
        public void DeleteExistingClaim(Claims nextClaim)
        {
            _claims.Dequeue();
        }
        //Get Next Claim
        public Claims GetNextClaim()
        {
            return _claims.Peek();
            
        }

    }
}

