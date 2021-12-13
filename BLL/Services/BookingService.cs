using DLL.Models;
using DLL.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService
    {
        private readonly BookingRepository bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task BookingTicket(Booking booking)
        {
            await bookingRepository.CreateAsync(booking);
        }
        public async Task ChangeBookingStatus(Booking booking)
        {
            var bookingTemp = await bookingRepository.GetAllAsync();

            if(bookingTemp.First(x => x.Id == booking.Id) != null)
                await bookingRepository.UpdateEntityAsync(booking).ConfigureAwait(false);
        }
    }
}
