using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.IServices
{
    public interface IStatVowelServise
    {
        Task<StatVowels> addEditVowels(StatVowels oStatVowels);

       // Task<IEnumerable<StatVowels>> getAllPosts();
       // Task<StatVowels> getPostbyId(int postId);

        Task<StatVowels> DeletePost(int postId);

       
    }
}
